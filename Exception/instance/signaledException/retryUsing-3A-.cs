retryUsing: alternativeBlock
	
"Abort an exception handler and evaluate a new block in place of the handler's protected block."

	handlerContext receiver: alternativeBlock.
	self retry