initOopMap
	"oopMap is an array 4096 long indexed by basicHash.
	Each element a subarray of object/newOop/hash triplets.
	The subarrrays must be linearly searched.
	Access to an object causes it to be promoted in the subarray,
		so that frequently accessed objects can be found quickly."
	oopMap _ (1 to: 4096) collect: [:i | Array new].

	"replacementClasses is a simple Dictionary to contain pairs of classes (well, globals should work actually) where the key is a class being replaced and the value is the replacement class"
	replacementClasses _ Dictionary new