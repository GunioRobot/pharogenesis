setForm: aForm

	| screen blackWord |
	self reset.
	form _ aForm.
	port _ GrafPort toForm: form.
	shadowDrawing _ false.

	"Build a 50% stipple of black for the given depth."
	screen _ Color pixelScreenForDepth: form depth.
	blackWord _ Color black pixelWordForDepth: form depth.
	shadowStipple _
		(screen collect: [:maskWord | maskWord bitAnd: blackWord]).
