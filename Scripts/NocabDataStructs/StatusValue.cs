public class StatusValue {
    /**
     * TODO: 
     * Make this class a MonoBehaviour and let it draw itself to the screen?
     */

    public int max;
    public int current;

    // Simple constructor
    public StatusValue(int maxValue, int currentValue) {
        this.max = maxValue;
        this.current = currentValue;
    }

    /**
     * Constructor. Provide maxValue and if the current should
     * start at 0 or the max.
     */
    public StatusValue(int maxValue, bool startAtMax = true) : 
        this(maxValue, (startAtMax) ? (maxValue) : (0)) { }


    // Simple Constructor, initiliazes everything to 0
    public StatusValue() : this(0, 0) {}

};