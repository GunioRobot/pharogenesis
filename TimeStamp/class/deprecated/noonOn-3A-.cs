noonOn: aDate
	"Answer a new instance that represents aDate at noon."

	^ self 
		deprecated: 'Deprecated';
		date: aDate time: Time noon