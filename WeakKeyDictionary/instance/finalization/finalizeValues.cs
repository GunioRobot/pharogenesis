finalizeValues
	"default action is to re-hash the receiver and to remove nil-keys"
	self rehash.
	self removeKey: nil ifAbsent:[].