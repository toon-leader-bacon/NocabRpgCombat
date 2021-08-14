using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusValue_MonoUI : MonoBehaviour
{
  /**
   * A pokemon style HP bar. 
   */

  #region public
  public void setNewMax(float newMaxValue)
  {
    /**
     * @brief update the max value of the slider, which may result on a redraw
     * on the next frame (if a different value is provided)
     */
    slider.maxValue = newMaxValue;
  }

  public void setNewValue(float newValue)
  {
    /**
     * @brief Update the value of this slider, which will result on a redraw
     * on the next frame.
     */
    this.slider.value = newValue;
  }

  public void redraw(StatusValue dataToShow)
  {
    /**
     * @brief use the provided data to draw a slider UI to the screen.
     * This is an Instant transition to the new value. For smooth animations
     * use the redraw_lerp function.
     * @param dataToShow the data to draw to the UI
     */
    this.setNewMax(dataToShow.Max);
    this.setNewValue(dataToShow.Current);
  }

  public void redraw_lerp(int newValue, float secondsToLerp)
  {
    /**
     * @brief Begin a new animation, that moves the UI slider value smoothly 
     * to the new target value
     * @param newValue the endpoint of the animation/ target value for the
     * slider
     * @param secondsToLerp how long should the animation take?
     */
    lerpStartTime = Time.time;
    lerpTotalDurration = secondsToLerp;
    lerpTargetValue = newValue;
    lerpInitialValue = slider.value;
    isRedrawing = true;
  }
  #endregion public

  #region private

  private Slider slider;

  private bool isRedrawing = false;
  private float lerpInitialValue;
  private float lerpTargetValue;
  private float lerpStartTime;
  private float lerpTotalDurration;

  private void Start()
  {
    this.slider = this.GetComponent<Slider>();
  }

  private void Update()
  {
    if (isRedrawing)
    {
      updateLerp();
    }
  }

  private void updateLerp()
  {
    /**
     * @brief the actual guts of executing a lerp animation
     * See the redraw_lerp() function for common usage
     */
    float deltaTime = Time.time - lerpStartTime;
    float t = Mathf.Clamp(deltaTime / lerpTotalDurration, 0f, 1f);
    // The variable t increases with time
    float lerpedValue = NocabMathUtility.lerp_fast(lerpInitialValue, lerpTargetValue, t);
    this.setNewValue(lerpedValue);

    if (deltaTime >= lerpTotalDurration)
    {
      // If we've lerped for long enough
      endAnimation();
    }
  }

  public void endAnimation()
  {
    /**
     * @brief Stops an animation if one is running, otherwise a no-op.
     * If an animation is running and this function is called, the slider will
     * be set to whatever value was targed by the animation.
     */
    if (isRedrawing)
    {
      isRedrawing = false;
      this.setNewValue(lerpTargetValue);
    }
  }

  #endregion private

}
