import os
import shutil

file_num = 1

for root, dirs, files in os.walk(".\\Results"):
    for file in files:
        if file.endswith(".xml"):
            print(os.path.join(root, file))
            shutil.move(os.path.join(root, file), '.\\Results\\{}.xml'.format(file_num))
            file_num += 1
