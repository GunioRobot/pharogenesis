assuredPropertyDictionary
	"Return the receiver's property dictionary, creating it if necessary.  Properties are accessed only by symbol, so an IdentityDictionary is used for speed"
	properties ifNil: [properties _ IdentityDictionary new].
	^ properties