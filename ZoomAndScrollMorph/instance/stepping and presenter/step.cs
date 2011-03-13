step

	| innerPasteUp overlap |

	innerPasteUp _ self myTransformMorph firstSubmorph.
	overlap _ (innerPasteUp submorphs 
		inject: 0@0 
		into: [ :min :each | min min: each position]) rounded.
	overlap = (0@0) ifFalse: [
		innerPasteUp submorphs do: [ :each | each position: each position - overlap].
		innerPasteUp layoutChanged.
	].



