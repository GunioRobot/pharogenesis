privateGreen
	"Private! Answer the internal representation of my green component."

	^ (rgb >> GreenShift) bitAnd: ComponentMask