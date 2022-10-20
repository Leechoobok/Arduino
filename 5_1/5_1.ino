const int inputPin = 2;

void setup(){
    pinMode(LED_BUILTIN, OUTPUT);
    pinMode(inputPin, INPUT);
    Serial.begin(9600);
}

void loop(){
    int val = digitalRead(inputPin);
    if(val == HIGH){
        digitalWrite(LED_BUILTIN, HIGH);

        Serial.print("HIGH");

    }
    else{
        digitalWrite(LED_BUILTIN, LOW);
        Serial.print("LOW");

    }

}