#Based on Unity Hand Tracking with Mediapipe python
#Configs
ShowCamImage = False 
#Configs








import socket
 
UDP_IP = "127.0.0.1"
UDP_PORT = 8051



import cv2
import mediapipe as mp
mp_drawing = mp.solutions.drawing_utils
mp_drawing_styles = mp.solutions.drawing_styles
mp_hands = mp.solutions.hands

# For static images:
IMAGE_FILES = []
with mp_hands.Hands(
    static_image_mode=True,
    max_num_hands=2,
    min_detection_confidence=0.5) as hands:
  for idx, file in enumerate(IMAGE_FILES):
    # Read an image, flip it around y-axis for correct handedness output (see
    # above).
    image = cv2.flip(cv2.imread(file), 2)
    # Convert the BGR image to RGB before processing.
    results = hands.process(cv2.cvtColor(image, cv2.COLOR_BGR2RGB))

    print(results.multi_hand_world_landmarks)

    # Print handedness and draw hand landmarks on the image.
    print('Handedness:', results.multi_handedness)

    if not results.multi_hand_landmarks:
      continue
    image_height, image_width, _ = image.shape
    annotated_image = image.copy()
    for hand_landmarks in results.multi_hand_landmarks:
      print('hand_landmarks:', hand_landmarks)
      print(
          f'Index finger tip coordinates: (',
          f'{hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP].x * image_width}, '
          f'{hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP].y * image_height})'
      )
      


      mp_drawing.draw_landmarks(
          annotated_image,
          hand_landmarks,
          mp_hands.HAND_CONNECTIONS,
          mp_drawing_styles.get_default_hand_landmarks_style(),
          mp_drawing_styles.get_default_hand_connections_style())
    cv2.imwrite(
        '/tmp/annotated_image' + str(idx) + '.png', cv2.flip(annotated_image, 1))
    # Draw hand world landmarks.
    if not results.multi_hand_world_landmarks:
      continue
    for hand_world_landmarks in results.multi_hand_world_landmarks:
      mp_drawing.plot_landmarks(
        hand_world_landmarks, mp_hands.HAND_CONNECTIONS, azimuth=5)





# For webcam input:
cap = cv2.VideoCapture(0)
with mp_hands.Hands(
    model_complexity=0,
    min_detection_confidence=0.5,
    min_tracking_confidence=0.5) as hands:
  while cap.isOpened():
    success, image = cap.read()
    if not success:
      print("Ignoring empty camera frame.")
      # If loading a video, use 'break' instead of 'continue'.
      continue

    # To improve performance, optionally mark the image as not writeable to
    # pass by reference.
    image.flags.writeable = False
    image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    results = hands.process(image)

    # Draw the hand annotations on the image.
    image.flags.writeable = True
    image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
    if results.multi_hand_landmarks:
      for hand_landmarks in results.multi_hand_landmarks:
        #print(hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP].x)
        
        UDP_PORT = 8051

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.WRIST].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.WRIST].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.WRIST].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))




        UDP_PORT = 8052

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_CMC].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_CMC].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_CMC].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))






        UDP_PORT = 8053

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_MCP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_MCP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_MCP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))





        UDP_PORT = 8054

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_IP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_IP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_IP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))





        UDP_PORT = 8055

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_TIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_TIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.THUMB_TIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))




        UDP_PORT = 8056

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_MCP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_MCP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_MCP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))




        UDP_PORT = 8057

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_PIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_PIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_PIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))





        UDP_PORT = 8058

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_DIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_DIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_DIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))



        
        UDP_PORT = 8059

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))



        
        UDP_PORT = 8060

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_MCP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_MCP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_MCP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))




        
        
        UDP_PORT = 8061

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_PIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_PIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_PIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))



        
        
        UDP_PORT = 8062

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_DIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_DIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_DIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))


                



        UDP_PORT = 8063

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_TIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_TIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_TIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))





        


        UDP_PORT = 8064

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_MCP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_MCP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_MCP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))





                


        UDP_PORT = 8065

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_PIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_PIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_PIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))






                


        UDP_PORT = 8066

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_DIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_DIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_DIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))

                        


        UDP_PORT = 8067

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_TIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_TIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.RING_FINGER_TIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))




                        


        UDP_PORT = 8068

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_MCP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_MCP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_MCP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))


                        


        UDP_PORT = 8069

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_PIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_PIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_PIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))










                        


        UDP_PORT = 8070

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_DIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_DIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_DIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))








        UDP_PORT = 8071

        v1 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_TIP].x * 35))
  #      v1 = v1[:-len(v1) + 4]
        
        v2 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_TIP].y * 35))
 #       v2 = v2[:-len(v2) + 4]
        
        v3 = str((hand_landmarks.landmark[mp_hands.HandLandmark.PINKY_TIP].z * 35))
#        v3 = v3[:-len(v3)  + 4]
        

        MESSAGE = bytes(v1 + ";" + v2  + ";" + v3, 'utf-8')
        print("UDP target IP: %s" % UDP_IP)
        print("UDP target port: %s" % UDP_PORT)
        print("message: %s" % MESSAGE)

        sock = socket.socket(socket.AF_INET, # Internet
                    socket.SOCK_DGRAM) # UDP
        sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))

















        mp_drawing.draw_landmarks(
            image,
            hand_landmarks,
            mp_hands.HAND_CONNECTIONS,
            mp_drawing_styles.get_default_hand_landmarks_style(),
            mp_drawing_styles.get_default_hand_connections_style())
    # Flip the image horizontally for a selfie-view display.
    if ShowCamImage:
      cv2.imshow('Mighty Handtracking with mediapipe', cv2.flip(image, 1))
    
    if cv2.waitKey(5) & 0xFF == 27:
      break
cap.release()