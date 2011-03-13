comments
	^ self classNames collect: [:ea | (environment at: ea) asCommentNode ]