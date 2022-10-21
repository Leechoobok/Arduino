int blinkDelay = 0;
int mode = 0;
unsigned long pre_t, cur_t;
void setup(){
    Serial.begin(9600);
    pinMode(LED_BUILTIN, OUTPUT);
    pre_t = millis();
}

void loop(){
    cur_t=millis();
    if(Serial.available())
    {
        char ch = (char) Serial.read();
        if(isDigit(ch)){
            blinkDelay = (ch-'0');
            blinkDelay = blinkDelay * 100;
        }
    }    
    
    if(cur_t-pre_t>=blinkDelay){
        pre_t=cur_t;
        mode = !mode;
        digitalWrite(LED_BUILTIN,mode);    
    }
}