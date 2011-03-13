loadImages5
	"Do not execute this! Just for one-time initialization.  Bring in the single cover image from a BMP files to a form."

	| coverForm |
	coverForm _ Form fromBMPFileNamed: 'eToy_cover.BMP' depth: 16.
	self formDictionary at: 'CoverMain' put: coverForm.
	coverForm removeZeroPixelsFromForm.
	coverForm shapeFill: (Color r: 0.2 g: 0.2 b: 0.2) interiorPoint: 2@2.
	coverForm displayAt: 300@300.
