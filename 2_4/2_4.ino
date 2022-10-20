int inputPins[]= {2, 3, 4, 5};
int ledPins[] = {10, 11, 12, 13};

void setup(){
    for (int index = 0; index <4; index++){
        pinMode(ledPins[index], OUTPUT);
        pinMode(inputPins[index], INPUT_PULLUP);
    }
}
void loop(){
    for(int index = 0; index < 4; index++){
        
        int val = digitalRead(inputPins[index]);
        if(val == LOW){
            digitalWrite(ledPins[index], HIGH);
        }
        else{
            digitalWrite(ledPins[index],LOW);
        }
    }
}