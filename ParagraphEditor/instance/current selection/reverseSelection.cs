reverseSelection
	"Reverse the valence of the current selection highlighting."
	selectionShowing _ selectionShowing not.
	paragraph reverseFrom: self pointBlock to: self markBlock