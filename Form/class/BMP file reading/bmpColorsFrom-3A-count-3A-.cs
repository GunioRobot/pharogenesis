bmpColorsFrom: aBinaryStream count: colorCount
	"Read colorCount BMP color map entries from the given binary stream. Return an array of colors."

	| colors b g r |
	colorCount = 0 ifTrue: [
		"default colors for 1-bit BMP file that do not supply a color map"
		^ Array with: Color white with: Color black].

	colors _ Array new: colorCount.
	1 to: colors size do: [:i |
		b _ aBinaryStream next.
		g _ aBinaryStream next.
		r _ aBinaryStream next.
		aBinaryStream skip: 1.
		colors at: i put: (Color r: r g: g b: b range: 255)].
	^ colors
