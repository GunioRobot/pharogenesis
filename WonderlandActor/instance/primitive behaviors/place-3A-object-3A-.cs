place: aLocation object: aTarget
	"Moves this object to one of several pre-determined locations relative to the target object."

	 ^ self place: aLocation object: aTarget duration: 1.0 style: gently.
