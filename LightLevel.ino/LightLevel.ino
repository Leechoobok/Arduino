
const int sensorPin = A0;

void setup() {
  // put your setup code here, to run once:
  pinMode(LED_BUILTIN, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  int delayval = analogRead(sensorPin);
  Serial.println(delayval);
  digitalWrite(LED_BUILTIN, HIGH);
  delay(delayval);
  digitalWrite(LED_BUILTIN, LOW);
  delay(delayval);
}