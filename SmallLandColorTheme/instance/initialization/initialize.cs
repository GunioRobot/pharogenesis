initialize
	"Initialize the receiver"
	| baseColors |
	super initialize.
	""
	baseColors := self baseColors.
	""
	darks := baseColors first wheel: 8.
	normals := baseColors second wheel: 8.
	lights := baseColors third wheel: 8