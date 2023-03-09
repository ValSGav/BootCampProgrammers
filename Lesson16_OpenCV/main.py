import cv2

face_cascades = cv2.CascadeClassifier(cv2.data.haarcascades + "haarcascade_frontalface_default.xml")

# img = cv2.imread('C:/GeekBrains/bootcamp/Lesson16_OpenCV/astro.jpg')
# cv2.imshow('result',img)
# cv2.waitKey(1000)

# img = cv2.resize(img, (500,500))
# cv2.imshow('result',img)
# cv2.waitKey(1000)

cap = cv2.VideoCapture(0)

# while True:
#     succes, frame = cap.read()
#     cv2.imshow('Camera capture', frame)
#     if cv2.waitKey(1) & 0xff == ord('q'):
#         break

img = cv2.imread('C:/GeekBrains/bootcamp/Lesson16_OpenCV/face.jpg')
imggr = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)


faces = face_cascades.detectMultiScale(imggr)


for (x, y, w, h) in faces:
    cv2.rectangle(img, (x,y), (x+w, y+h), (0,255,30), 3)
cv2.imshow('result',img)
cv2.waitKey(0)