mapData 
	"Force the data through the map (permutation) to create the data to test."

	thisData _ data collect: [:realData |
					argMap collect: [:ind | realData at: ind]].
		