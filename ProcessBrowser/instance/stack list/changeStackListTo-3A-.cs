changeStackListTo: aCollection 

        stackList _ aCollection.
        self changed: #stackNameList.
        self stackListIndex: 0