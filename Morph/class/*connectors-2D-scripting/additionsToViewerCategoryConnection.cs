additionsToViewerCategoryConnection
	"Answer viewer additions for the 'connection' category"
	"Vocabulary initialize"

	^{
		#'connections to me'.
		#(
		(command tellAllPredecessors: 'Send a message to all graph predecessors' ScriptName)
		(command tellAllSuccessors: 'Send a message to all graph predecessors' ScriptName)
		(command tellAllIncomingConnections: 'Send a message to all the connectors whose destination end is connected to me' ScriptName)
		(command tellAllOutgoingConnections: 'Send a message to all the connectors whose source end is connected to me' ScriptName)
		(slot incomingConnectionCount 'The number of connectors whose destination end is connected to me' Number readOnly Player getIncomingConnectionCount unused unused)
		(slot outgoingConnectionCount 'The number of connectors whose source end is connected to me' Number readOnly Player getOutgoingConnectionCount unused unused)
		)
	}
