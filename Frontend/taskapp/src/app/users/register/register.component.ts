import { PhotosService } from '../../core/services/photos.service';
import { UsersService } from '../../core/services/users.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {Router} from '@angular/router'; 

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  fileToUpload: File | null = null;
  isLoading: boolean = false;
  
  constructor(
    private userService: UsersService,
    private photoService: PhotosService,
    private router: Router,
    private fb: FormBuilder,) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      firstName: [''],
      lastName: [''],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  public registerUser(): void{
    this.isLoading = true;
    this.userService.createUser(this.registerForm.value)
      .subscribe((response: any) => {
        if (this.fileToUpload) {
          this.photoService.uploadPhotoForUser(response.id, this.fileToUpload)
            .subscribe(_ => {
              this.isLoading = false;
              this.router.navigate(['/login']);
            });
        } else {
          this.isLoading = false;
          this.router.navigate(['/login']);
        }      
      });
  }

  public handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }
}
