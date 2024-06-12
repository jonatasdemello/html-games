import matplotlib.pyplot as plt
import numpy as np

def Fx1(x):
    return (x**3 + 3 * x**2 - 6*x - 8) / 4

def Fx2(x):
    return (x**2 - x - 2)

def Fx3(x):
    return (x**3 - 3*x)

# Generate x values
x_values = np.arange(-5.0, 5.0, 0.05)

# Calculate corresponding y values using Fx(x)
y_values = Fx3(x_values)

# Create the plot
#plt.figure(figsize=(8, 6))
plt.plot(x_values, y_values, color='orange', linewidth=2)

#plt.scatter([50 + t*8 for t in x_values], [50 - y*4 for y in y_values], color='blue', s=5)

# Set plot properties
plt.title("Graph of F(x)")
plt.xlabel("x")
plt.ylabel("F(x)")
plt.grid(True)

# Show the plot
plt.show()
