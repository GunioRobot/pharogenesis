formatOfCls: class
	"Return the full word value that encodes instSize, bits, bytes, and variable."
	"See the comment in Behavior format:variable:words:pointers:
	NB: we must clear the compact class related field and replace it with the value from the cloner's list of compact classes"
	| ccField |
	ccField _ compactClasses indexOf: class.	"0 means need full word for class "
	^ (class format bitClear: (2r11111 bitShift:11)) bitOr: (ccField bitShift:11)