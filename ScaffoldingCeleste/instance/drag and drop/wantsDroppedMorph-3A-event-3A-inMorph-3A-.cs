wantsDroppedMorph: transferMorph event: anEvent inMorph: destinationLM 
	"We are only interested in TransferMorphs as wrappers for             
	informations. If their content is really interesting for us, will             
	determined later in >>acceptDroppingMorph:event:."

	| srcType dstType |

	"only want drops on lists (not, for example, on pluggable texts)"
	(destinationLM isKindOf: PluggableListMorph) ifFalse: [^ false].

	srcType _ transferMorph dragTransferType.
	dstType _ destinationLM getListSelector.

	(srcType = #tocEntryList) ifFalse: [^false].	"Only messages from TOC"
	(dstType = #categoryList) ifFalse: [^false].	"Only drop into category list"

	^true