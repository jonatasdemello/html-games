import matplotlib.pyplot as plt
import math

# Initialize empty lists to store x and y coordinates
x_coords = []
y_coords = []

# Iterate over the range of t values
# 12.56 / 0.05 = 251.2
for t in range(int(12.56 / 0.05)):
    t_val = t * 0.05
    x = 20 * math.cos(t_val) + 30 * math.cos(1.5 * t_val)
    y = 20 * math.sin(t_val) - 30 * math.sin(1.5 * t_val)
    v = 100 - y
    h = 128 + x
    x_coords.append(h * 2)
    y_coords.append(v * 2)

# Plot the points
plt.scatter(x_coords, y_coords, color='blue', s=1)
plt.xlabel('Horizontal Position')
plt.ylabel('Vertical Position')
plt.title('Points from JavaScript Code')
plt.grid(True)
plt.show()
