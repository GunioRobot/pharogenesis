asDate
	"Many allowed forms, see Date.readFrom:"
	^ Date readFrom: (ReadStream on: self)