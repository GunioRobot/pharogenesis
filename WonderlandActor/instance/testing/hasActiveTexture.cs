hasActiveTexture
	"Return true if the receiver has an active texture that wants events routed directly."
	^(self getProperty: #activeTexture) == true