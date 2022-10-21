bool switch_cnt = false;
int put_cnt=0;
unsigned long time_previous, time_current;
void setup(){
    pinMode(LED_BUILTIN,OUTPUT);
    Serial.begin(9600);
    time_previous=millis();
}

void loop(){
    time_current=millis();

    if(time_current - time_previous >=100){
        time_previous = time_current;
        
        if (put_cnt==100) switch_cnt=true;
        else if(put_cnt==0) switch_cnt=false; 
        if (switch_cnt == false) put_cnt++;
        else if(switch_cnt == true) put_cnt--;
        Serial.println(put_cnt);
    }
    
    
    if(Serial.available()){
        char ch = (char) Serial.read();
        if(isDigit(ch)){
            if((ch - '0') == 1){
                digitalWrite(LED_BUILTIN,HIGH);
            }
            else if((ch - '0') == 0){
                digitalWrite(LED_BUILTIN,LOW);
            }
        }
    }
}