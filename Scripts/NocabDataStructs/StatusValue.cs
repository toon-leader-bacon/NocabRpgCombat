using System.Threading;
using System.Globalization;
using System;
using UnityEngine;

public class StatusValue
{
  /**
   * TODO: 
   * Make this class a MonoBehaviour and let it draw itself to the screen?
   */


  // TODO: Conside adding a min value too
  private int max_;
  public int Max { get { return this.max_; } }

  private int current_;
  public int Current { get { return this.current_; } }

  public bool isPositive { get { return this.max_ > 0; } }

  // Simple constructor
  public StatusValue(int maxValue, int currentValue)
  {
    this.max_ = maxValue;
    this.current_ = currentValue;
  }

  /**
   * Constructor. Provide maxValue and if the current should
   * start at 0 or the max.
   */
  public StatusValue(int maxValue, bool startAtMax = true) :
      this(maxValue, (startAtMax) ? (maxValue) : (0))
  { }


  // Simple Constructor, initializes everything to 0
  public StatusValue() : this(0, 0) { }


  public void addToCurrent(int valueToAdd, bool breakMax = false)
  {
    this.current_ += valueToAdd;
    if (!breakMax)
    {
      // If we're NOT allowed to go over the max with this addition
      normalize();
    }
  }

  public void subtractCurrent(int valueToSubtract)
  {
    this.current_ -= valueToSubtract;
    // TODO: Consider implimenting a min value? 
  }


  private void normalize()
  {
    /**
     * @brief ensure the current value is less than or equal to the max.
     */
    this.current_ = Mathf.Min(this.current_, this.max_);
  }

  public static bool operator ==(StatusValue left, int right)
  {
    return left.current_ == right;
  }

  public static bool operator !=(StatusValue left, int right)
  {
    return left.current_ != right;
  }

  public static bool operator <=(StatusValue left, int right)
  {
    return left.current_ <= right;
  }
  public static bool operator >=(StatusValue left, int right)
  {
    return left.current_ >= right;
  }

  public static bool operator <(StatusValue left, int right)
  {
    return left < right;
  }
  public static bool operator >(StatusValue left, int right)
  {
    return left.current_ > right;
  }

};