writeIdentitySet: obj 
	"Elements of a Set need to be reordered owing to new oops."
	^ self writeSet: obj useIdentity: true