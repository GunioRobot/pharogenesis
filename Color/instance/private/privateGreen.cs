privateGreen
	"Private! Return the internal representation of my green component."

	^ (rgb >> GreenShift) bitAnd: ComponentMask