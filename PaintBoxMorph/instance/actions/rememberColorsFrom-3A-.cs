rememberColorsFrom: aForm
	"Tell my colorMemory to show the colors this form has used."

	"The new color picker does not remember colors"
"	colorMemory clear.
	aForm colorsUsed do: [:val | colorMemory mark: val].
	colorMemory invalidRect: colorMemory bounds.
"