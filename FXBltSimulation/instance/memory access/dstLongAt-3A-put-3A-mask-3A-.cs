dstLongAt: idx put: srcValue mask: dstMask
	"Store the given value back into destination form, using dstMask
	to mask out the bits to be modified. This is an essiantial
	read-modify-write operation on the destination form."
	| dstValue |
	self inline: true.
	dstValue _ self dstLongAt: idx.
	dstValue _ dstValue bitAnd: dstMask.
	dstValue _ dstValue bitOr: srcValue.
	self dstLongAt: idx put: dstValue.