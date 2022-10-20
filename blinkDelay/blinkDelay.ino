
int blinkDelay = 0;

void setup(){

    Serial.begin(9600);
    pinMode(LED_BUILTIN, OUTPUT);
}

void loop(){
    
    if(Serial.available()){
        char ch = (char) Serial.read();
         if(isDigit(ch)){
            switch ((ch-'0'))
            {
            case 0:
                blinkDelay = 0;
                break;
            case 1:
                blinkDelay = 100;
                break;
            case 2:
                blinkDelay = 200;
                break;
            case 3:
                blinkDelay = 300;
                break;
            case 4:
                blinkDelay = 400;
                break;
            case 5:
                blinkDelay = 500;
                break;
            case 6:
                blinkDelay = 600;
                break;
            case 7:
                blinkDelay = 700;
                break;
            case 8:
                blinkDelay = 800;
                break;
            case 9:
                blinkDelay = 900;
                break;
            default:
                blinkDelay = 50;
                break;
            }
         }
    }
    digitalWrite(LED_BUILTIN,HIGH);
    delay(blinkDelay);
    digitalWrite(LED_BUILTIN,LOW);
    delay(blinkDelay);


}