show5

    " B3DDemoSpheres new show5"

     | view |

  self createScene5.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene5;
     scene: scene.
  view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view openInSystemWindow.