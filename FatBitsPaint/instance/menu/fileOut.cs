fileOut

        | fileName result |

        result _ StandardFileMenu newFile ifNil: [^ 1 beep].
        fileName _ result directory fullNameFor: result name.
        Cursor normal showWhile:
                [self unmagnifiedForm writeOnFileNamed: fileName]