setInterpreter: anInterpreter
	"Interface for InterpreterSimulator. Allows BitBltSimulation object to send messages to the interpreter. The translator will replace sends to 'interpreterProxy' with sends to self, as if BitBltSimulation were part of the interpreter."

	interpreterProxy _ anInterpreter.