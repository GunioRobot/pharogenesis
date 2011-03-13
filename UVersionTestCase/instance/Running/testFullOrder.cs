testFullOrder
	"check that all versions are in some order"

	typicalVersions do: [ :v1 |
		typicalVersions do: [ :v2 |
			self should: [
				(v1 < v2)
				or: [ (v2 < v1) 
				or: [ v1 = v2 ] ] ] ] ]



	