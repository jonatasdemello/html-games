import matplotlib.pyplot as plt
import numpy as np

# Initialize the figure and axis for plotting
fig, ax = plt.subplots()

# Main drawing logic
for Y in np.arange(-10, 10, 0.2):
    for X in np.arange(-10, 10, 0.3):
        R = np.sqrt(X**2 + Y**2) * 1.5
        F = 90
        if R > 0:
            F = abs(90 * np.sin(R) / R)
        A = int(10 * X + 160 - 5 * Y)
        B = int(5 * Y + 2.5 * X + 93)
        ax.plot(A, B - F, 'o', color='black', markersize=1)

# Set the background color to black
#ax.set_facecolor('black')

# Set the aspect of the plot to be equal
#ax.set_aspect('equal')

# Remove the axes for a cleaner look
#plt.axis('off')

# Show the plot
plt.show()
