translateToWordyGetter: key
	"  setBlob:  becomes  's blob _  "

	^ '''s ', 
	  (self splitAtCapsAndDownshifted: (key asString allButFirst: 3) 
			withFirstCharacterDownshifted)