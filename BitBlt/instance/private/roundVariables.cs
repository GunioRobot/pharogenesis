roundVariables

	| maxVal minVal |
	maxVal _ SmallInteger maxVal.
	minVal _ SmallInteger minVal.
	destX _ destX asInteger min: maxVal max: minVal.
	destY _ destY asInteger min: maxVal max: minVal.
	width _ width asInteger min: maxVal max: minVal.
	height _ height asInteger min: maxVal max: minVal.
	sourceX _ sourceX asInteger min: maxVal max: minVal.
	sourceY _ sourceY asInteger min: maxVal max: minVal.
	clipX _ clipX asInteger min: maxVal max: minVal.
	clipY _ clipY asInteger min: maxVal max: minVal.
	clipWidth _ clipWidth asInteger min: maxVal max: minVal.
	clipHeight _ clipHeight asInteger min: maxVal max: minVal.
