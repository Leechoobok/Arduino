float value = 1.1;
void setup(){
    Serial.begin(9600);
}
void loop(){

    value=value-0.1;
    if(value==0){
        Serial.println("The Value is exactly zero");
    }
    else if(almostEqual(value, 0))
    {
        Serial.println("The value ");
        Serial.print(value,7);
        Serial.println(" is almost ezual to zero, restarting countdown");
        value = 1.1;
    }
    else
    {
        Serial.println(value);
    }
    delay(250);
}

bool almostEqual(float a, float b){
    const float DELTA = .00001;
    if(a==0) return fabs(b) <= DELTA;
    if(b==0) return fabs(a) <= DELTA;
    return fabs((a - b) / max(fabs(a), fabs(b))) <= DELTA;
}
