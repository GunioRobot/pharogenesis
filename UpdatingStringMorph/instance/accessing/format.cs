format
	"Answer the receiver's format: #default or #string"

	^ format ifNil: [format _ #default]