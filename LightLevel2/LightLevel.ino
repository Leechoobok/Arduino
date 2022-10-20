
const int sensorPin = A0;

const int low = 200;
const int high = 800;

const int minDuration = 100;
const int maxDuration = 1000;

void setup() {
  // put your setup code here, to run once:
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  int delayval = analogRead(sensorPin);
  delayval = map(delayval, low, high, minDuration, maxDuration);
  delayval = constrain(delayval, minDuration, maxDuration);
  digitalWrite(LED_BUILTIN, HIGH);
  delay(delayval);
  digitalWrite(LED_BUILTIN, LOW);
  delay(delayval);
}