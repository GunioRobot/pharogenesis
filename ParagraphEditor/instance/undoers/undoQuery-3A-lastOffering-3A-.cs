undoQuery: hintText lastOffering: selectorOrNil
	"Undo ctrl-q.  selectorOrNil (if not nil) is the previously offered selector.
	 hintText is the original hint.  Redoer: completeSymbol."

	self zapSelectionWith: UndoSelection.
	self undoMessage: (Message selector: #completeSymbol:lastOffering: arguments: UndoMessage arguments) forRedo: true.
	self selectAt: self stopIndex