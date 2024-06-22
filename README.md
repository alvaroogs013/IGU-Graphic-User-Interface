
<h1>Car Rental Management System</h1>
    <p>This project consists of several C# files that create a functional user interface for managing a car rental company's data. The application includes various windows for viewing, adding, and analyzing car data using line and bar charts.</p>

  <h2>Main Features</h2>
    <p>The application provides the following functionalities:</p>
    <ul>
        <li>View all vehicle data in a main window, with details of a selected vehicle displayed below.</li>
          <img src="https://github.com/alvaroogs013/IGU-Graphic-User-Interface/assets/131161276/763aa6f8-6b12-49fa-b0e6-bd41a4daee2e"/>
        <li>Add new cars through a dedicated window.</li>
        <img src="https://github.com/alvaroogs013/IGU-Graphic-User-Interface/assets/131161276/f7986a13-b048-4e54-aa37-bca48bc946ba"/>
        <li>Add some usage for any car<li>
            <img src="https://github.com/alvaroogs013/IGU-Graphic-User-Interface/assets/131161276/35bd895b-fb4c-4aa1-8059-f8236b3bdfe8"/>
         <li>Analyze car usage data through line and bar charts in separate windows.</li>
            <img src="https://github.com/alvaroogs013/IGU-Graphic-User-Interface/assets/131161276/79f9b98c-44b3-44f9-8c37-29fd0f750b0a"/>
            <img src="https://github.com/alvaroogs013/IGU-Graphic-User-Interface/assets/131161276/7e1504c9-5144-4ebf-9312-14ac7af48f37"/>
   </ul>

  <h2>MainWindow Class</h2>
    <p>The <strong>MainWindow</strong> class handles the main interface and includes the following methods:</p>
    <ul>
        <li><strong>Private void DrawEjes():</strong> Draws the axes on the canvas.</li>
        <li><strong>Private void dibujaCoches():</strong> Draws three lines for each car, representing the general chart.</li>
        <li><strong>Private void dibujaUsos():</strong> Draws three polylines for each usage of a selected car in Table1.</li>
    </ul>

   <h2>Ventana2 Class</h2>
    <p>The <strong>Ventana2</strong> class manages the addition of new cars and usage data, with the following methods:</p>
    <ul>
        <li><strong>Private void Añadir_click():</strong> Adds new cars to Table1.</li>
        <li><strong>Private void AñadirUso_Click():</strong> Adds a new refuel record to Table2 for a selected car in Table1.</li>
        <li><strong>Private void Cancelar_Click():</strong> Clears the input fields without adding data.</li>
        <li><strong>Private void calcularMedias():</strong> Calculates the average consumption and cost as new refuels are added, updating the selected car's kilometers.</li>
    </ul>

  <h2>Event Delegations</h2>
    <p>The application uses several event delegations to manage data updates and selections:</p>
    <ul>
        <li><strong>public event EventHandler AddDataHandler:</strong> Triggered from Ventana2 to the main window when a new item is added to Table1, with a parameter of type Coches in AddEventArgs.</li>
        <li><strong>public event EventHandler ChangeDataHandler:</strong> Triggered from Ventana2 to the main window when an item is selected in Table1, displaying detailed data for each refuel.</li>
        <li><strong>public event EventHandler SwipeHandler:</strong> Triggered from Ventana2 to the main window when an item is deselected in Table1, switching from the specific diagram to the general diagram.</li>
    </ul>

  <h2>Usage</h2>
    <p>To compile and run the project, ensure you have all necessary files and dependencies. Open the solution in Visual Studio and build the project. Run the application to start managing car rental data effectively.</p>

  <h2>Conclusion</h2>
    <p>This Car Rental Management System provides a comprehensive solution for managing vehicle data, adding new cars, and analyzing usage through intuitive visualizations. It demonstrates the use of C# for building robust and user-friendly interfaces.</p>
