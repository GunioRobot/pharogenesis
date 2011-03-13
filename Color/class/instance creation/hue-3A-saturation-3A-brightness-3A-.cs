hue: hue saturation: saturation brightness: brightness
	"Create a color with the given hue, saturation, and brightness. Hue is given as the angle in degrees of the color on the color circle where red is zero degrees. Saturation and brightness are numbers in [0.0..1.0] where larger values are more saturated or brighter colors. For example:

	Color new setHue: 0 saturation: 1 brightness: 1

is pure red."

	^ self basicNew setHue: hue saturation: saturation brightness: brightness