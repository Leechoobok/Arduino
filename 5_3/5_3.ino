const int inputPin = 2;
const int debounceDelay = 10;
bool last_button_state = LOW;
int ledState = LOW;

bool debounce(int pin){
    bool state;
    bool previousState;

    previousState=digitalRead(pin);
    for(int counter = 0 ; counter < debounceDelay; counter ++){
        delay(1);
        state = digitalRead(pin);
        Serial.print("state : ");
        Serial.println(state);
        Serial.print("previousState : ");
        Serial.println(previousState);
        if(state != previousState){
            counter=0;
            previousState = state;
        }
        if(state==LOW)
            return true;
        else
            return false;
    }
}

void setup(){
    pinMode(LED_BUILTIN, OUTPUT);
    pinMode(inputPin, INPUT);
    Serial.begin(9600);

}

void loop(){
    bool button_state = debounce(inputPin);

    if(last_button_state != button_state && button_state == HIGH){
        ledState = !ledState;
        digitalWrite(LED_BUILTIN, ledState);
        Serial.println("change state");
    }    
    last_button_state = button_state;
}