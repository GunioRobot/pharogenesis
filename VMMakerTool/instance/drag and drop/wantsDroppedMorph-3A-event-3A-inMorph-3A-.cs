wantsDroppedMorph: transferMorph event: anEvent inMorph: destinationLM 
	"We are only interested in TransferMorphs as wrappers for             
	information. If their content is really interesting for us, will             
	determined later in >>acceptDroppingMorph:event:."

	"only want drops on the lists"
	^self listMorphs includes: destinationLM