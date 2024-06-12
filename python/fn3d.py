import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D

# Define the function f(x, y)
def f(x, y):
    return -np.square(np.cos(x**2) + np.cos(y**2))

# Generate x and y values
x_values = np.linspace(-2, 2, 100)
y_values = np.linspace(-2, 2, 100)
X, Y = np.meshgrid(x_values, y_values)

# Calculate corresponding z values using f(x, y)
Z = f(X, Y)

# Create a 3D plot
fig = plt.figure(figsize=(10, 8))
ax = fig.add_subplot(111, projection='3d')
ax.plot_surface(X, Y, Z, cmap='viridis', edgecolor='none')

# Set plot properties
ax.set_title(r"Surface Plot of $f(x, y) = -(\cos(x^2) + \cos(y^2))^2$")
ax.set_xlabel("x")
ax.set_ylabel("y")
ax.set_zlabel("f(x, y)")

# Show the plot
plt.show()
