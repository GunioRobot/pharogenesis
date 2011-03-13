globalFlapTabOrDummy: aName
	| gg |
	"Find a global flap tab by name.  May be either 'flap: Tools' or 'Tools'.  Be sure to supply a "

	(gg _ self globalFlapTab: aName) ifNil: [
		^ StringMorph contents: aName, ' can''t be found'].
	^ gg