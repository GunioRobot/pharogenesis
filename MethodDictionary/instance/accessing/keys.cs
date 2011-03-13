keys
	"Since method all method selectors are symbols it is more efficient 
	to use an IdentitySet rather than a Set."
	| aSet |
	aSet := IdentitySet new: self size.
	self keysDo: [:key | aSet add: key].
	^ aSet