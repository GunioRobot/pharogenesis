additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #((fog (
			(slot fogColor 'The color of fog being applied' Color readWrite 
				Player getFogColor Player setFogColor:)
			(slot fogType 'The type of fog being applied' Number readWrite 
				Player getFogType Player setFogType:)
			(slot fogDensity 'The density of fog being applied' Number readWrite 
				Player getFogDensity Player setFogDensity:)
			(slot fogRangeStart 'The range start of fog being applied' Number readWrite 
				Player getFogRangeStart Player setFogRangeStart:)
			(slot fogRangeEnd 'The range start of fog being applied' Number readWrite 
				Player getFogRangeEnd Player setFogRangeEnd:)
)))