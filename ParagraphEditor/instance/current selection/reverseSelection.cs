reverseSelection
	"Reverse the valence of the current selection highlighting."
	selectionShowing := selectionShowing not.
	paragraph reverseFrom: self pointBlock to: self markBlock